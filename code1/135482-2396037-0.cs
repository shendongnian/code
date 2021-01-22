    namespace ConsoleApplication1 {
        partial class DataClasses1DataContext { // extends the generated data-context
            public override void SubmitChanges(
                    System.Data.Linq.ConflictMode failureMode) {
                var delta = GetChangeSet();
                foreach (var item in delta.Inserts.OfType<IEntityCheck>()) {
                    if (!item.IsValid()) {
                        GetTable(item.GetType()).DeleteOnSubmit(item);
                    }
                }
                base.SubmitChanges(failureMode);
            }
        }
        public interface IEntityCheck { // our custom basic validation interface
            bool IsValid();
        }
        partial class SomeTable : IEntityCheck { // extends the generated entity
            public bool IsValid() { return this.Val.StartsWith("d"); }
        }
        static class Program {
            static void Main() {
                using (var ctx = new DataClasses1DataContext()) {
                    ctx.Log = Console.Out; // report what it does
                    ctx.SomeTables.InsertOnSubmit(new SomeTable { Val = "abc" });
                    ctx.SomeTables.InsertOnSubmit(new SomeTable { Val = "def" });
                    ctx.SubmitChanges();
                }
            }
        }
    }
