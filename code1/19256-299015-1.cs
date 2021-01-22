    class Mine {
        static List<Func<object, bool>> predicates;
        static List<Action<object>> actions;
        static Mine() {
            AddAction<A>(o => o.Hop());
            AddAction<B>(o => o.Skip());
        }
    
        static void AddAction<T>(Action<T> action) {
            predicates.Add(o => o is T);
            actions.Add(o => action((T)o);
        }
    
        static void RunAction(object o) {
            for (int i=0; o < predicates.Count; i++) {
                if (predicates[i](o)) {
                    actions[i](o);
                    break;
                }
            }
        }
        void Foo(object o) {
            RunAction(o);
        }
    }
