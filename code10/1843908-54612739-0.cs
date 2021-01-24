`C#
    public class C : INotifyPropertyChanged
    {
        public C(B owner, A notifyMe)
        {
            Owner = owner;
            PropertyChanged += notifyMe.MethodTriggeredByChangeinProp;
        }
        public B Owner { get; private set; }
        private bool prop;
        public bool Prop
        {
            get => prop;
            set
            {
                prop = value;
                NotifyPropertyChanged();
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
`
Class B doesn't actually need to be anything special, unless you want to know when an object of Class C is added to your list - then you need the `ObservableCollection` setup; otherwise, `List<C>` is fine.
Class A's `MethodTriggeredByChangeinProp` changes slightly:
`C#
    public class A
    {
        public List<B> listB;
        public void MethodTriggeredByChangeinProp(object sender, PropertyChangedEventArgs e)
        {
            if(sender is C responsibleC)
            {
                var responsibleB = responsibleC.Owner;
                var changedProp = e.PropertyName;
            }
        }
`
You now know the responsible instances of class B and class C in A whenever a property changes in C.
You may also want to take a look at the [Observer Pattern in .NET](https://docs.microsoft.com/en-us/dotnet/standard/events/how-to-implement-an-observer) for a more in-depth configuration.
