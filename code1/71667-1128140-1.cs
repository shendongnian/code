    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Reflection;
    class Program : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        static void Main() {
            var p = new Program();
            p.PropertyChanged += (s, a) => Console.WriteLine(a.PropertyName);
            p.Name = "abc";
        }
        protected void OnPropertyChanged<T>(Expression<Func<Program, T>> property) {
            MemberExpression me = property.Body as MemberExpression;
            if (me == null || me.Expression != property.Parameters[0]
                  || me.Member.MemberType != MemberTypes.Property) {
                throw new InvalidOperationException(
                    "Now tell me about the property");
            }
            var handler = PropertyChanged;
            if (handler != null) handler(this,
              new PropertyChangedEventArgs(me.Member.Name));
        }
        string name;
        public string Name {
            get{return name;}
            set {
                name = value;
                OnPropertyChanged(p=>p.Name);
            }
        }
    }
