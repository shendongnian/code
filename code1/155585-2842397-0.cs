    class EventLoop {
       List<Action> MyThingsToDo { get; set; }
       public void WillYouDo(Action thing) {
          this.MyThingsToDo.Add(thing);
       }
       public void Start(Action yourThing) {
          while (true) {
             Do(yourThing);
             foreach (var myThing in this.MyThingsToDo) {
                Do(myThing);
             }
             this.MyThingsToDo.Clear();
          }
       }
       void Do(Action thing) { 
          thing();
       }
    }
    class Program {
        static readonly EventLoop e = new EventLoop();
        static void Main() {
            e.Start(DoSomething);
        }
        static int i = 0;
        static void DoSomething() {
            Console.WriteLine("Doing something...");
            e.WillYouDo(() => {
                results += (i++).ToString();
            });
            Console.WriteLine(results);
        }
        static string results = "!";
    }
