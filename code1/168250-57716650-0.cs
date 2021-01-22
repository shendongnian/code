`
public class first
        {
            private int someV;
            public virtual object SomeV { get => someV; set => someV = (int)value; }
            public first() { }
        }
        public class two : first
        {
            private string someV;
            public override object SomeV { get => someV; set => someV = value.ToString(); }
            public two() { }
        }
`
and use of those:
`
first firstClass = new first();
firstClass.SomeV = 1;
two twoClass = new two();
twoClass.SomeV = "abcd";
`
