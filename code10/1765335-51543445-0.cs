	using Castle.DynamicProxy;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reactive.Disposables;
	using System.Reactive.Linq;
	using System.Reactive.Subjects;
	using System.Text;
	using System.Threading.Tasks;
	namespace WebProxyClientTester
	{
	   public class LiveResultPromise<R, L>
		{
			private Task<R> result;
			private IObservable<L> notification;
			public LiveResultPromise(Task<R> result, IObservable<L> notification)
			{
				this.result = result;
				this.notification = notification;
			}
			public Task<R> Result { get => result; set => result = value; }
			public IObservable<L> Notification { get => notification; set => notification = value; }
		}
		public class UserContact
		{
			public UserContact()
			{
			}
		}
		public class User
		{
			public User()
			{
			}
		}
		public class AddressBook
		{
			public AddressBook()
			{
			}
		}
		class Response
		{
			private int id;
			private dynamic result;
			private object error;
			public int Id { get => id; set => id = value; }
			public dynamic Result { get => result; set => result = value; }
			public object Error { get => error; set => error = value; }
		}
		class MutableInt
		{
			private int value;
			public MutableInt(int value)
			{
				this.Value = value;
			}
			public int Value { get => value; set => this.value = value; }
			public int GetAndIncrement()
			{
				int last = Value;
				Value++;
				return last;
			}
		}
		public interface MyInterface
		{
			LiveResultPromise<UserContact, UserContact> getUserContact(String username);
			LiveResultPromise<User, User> getUsers();
			LiveResultPromise<AddressBook, AddressBook> getAddressBook();
		}
		class Client
		{
			Subject<Response> wsResponse = new Subject<Response>();
			MutableInt idRequest = new MutableInt(1);
			public Client()
			{
			}
			public Subject<Response> WsResponse { get => wsResponse; set => wsResponse = value; }
			public dynamic Invoke<T, R>(String methodName, object[] arguments, Type returnType, T typeResult, R typeNotify)
			{
				int currentId = idRequest.GetAndIncrement();
				TaskCompletionSource<T> taskResult = new TaskCompletionSource<T>();
				IObservable<R> notification = Observable.Create<R>((result) =>
				{
					wsResponse.Subscribe((res) =>
					{
						if (currentId == res.Id)
						{                      
							result.OnNext(res.Result);
						}
					}, (error) => { });
					return Disposable.Create(() => Console.WriteLine("Observer has unsubscribed"));
				});
				LiveResultPromise<T, R> liveResultPromise = new LiveResultPromise<T, R>(taskResult.Task, notification);            
				return liveResultPromise;
			}
		}
		class ProxyUtils : IInterceptor
		{
			private Client client;
			public ProxyUtils(Client client)
			{
				this.client = client;
			}
			public void Intercept(IInvocation invocation)
			{
				System.Type genericType = invocation.Method.ReturnType;
				dynamic typeResult = null;
				dynamic typeNotify = null;
				if (genericType.GetGenericArguments().Length > 0)
				{
					if (genericType.GetGenericArguments().Length >= 1)
					{
						typeResult = genericType.GetGenericArguments()[0];
					}
					if (genericType.GetGenericArguments().Length >= 2)
					{
						typeNotify = genericType.GetGenericArguments()[1];
					}
				}
				var result = Activator.CreateInstance(typeResult);
				var notification = Activator.CreateInstance(typeNotify);
				invocation.ReturnValue = client.Invoke(invocation.Method.Name, invocation.Arguments, invocation.Method.ReturnType, result, notification);
			}
		}
		class TestCLientExample
		{
			private static MyInterface requestClient;
			static void Main(string[] args)
			{
				Client client = new Client();
				requestClient = new ProxyGenerator().CreateInterfaceProxyWithoutTarget<MyInterface>(new ProxyUtils(client));
				LiveResultPromise<User, User> users = requestClient.getUsers();
				LiveResultPromise<UserContact, UserContact> contact = requestClient.getUserContact("pippo");
				LiveResultPromise<AddressBook, AddressBook> addressBook = requestClient.getAddressBook();
				users.Notification.Subscribe((result) =>
				{
					Console.WriteLine("User Object");
				});
				contact.Notification.Subscribe((result) =>
				{
					Console.WriteLine("UserContact Object");
				});
				addressBook.Notification.Subscribe((result) =>
				{
					Console.WriteLine("AddressBook Object");
				});
				Response res1 = new Response();
				res1.Id = 1;
				res1.Result = new User();
				client.WsResponse.OnNext(res1);
				Response res2 = new Response();
				res2.Id = 2;
				res2.Result = new UserContact();
				client.WsResponse.OnNext(res2);
				Response res3 = new Response();
				res3.Id = 3;
				res3.Result = new AddressBook();
				client.WsResponse.OnNext(res3);
			}
		}
	}
