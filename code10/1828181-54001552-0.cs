    public class AnotherClass
    {
        private List<OuterClass> _OuterClassList;
        private List<InnerClass> _InnerClassList;
        private List<OuterClass> OuterClassList {
            get { return _OuterClassList; }
            set
            {
                _OuterClassList = value;
                InnerClassList = value.Select(a => a.InnerObject).ToList();
            }
        }
        private List<InnerClass> InnerClassList { get { return _InnerClassList; } set { InnerClassList = value; } }
        public void InsertOuterClassObject(OuterClass outerClassObject)
        {
            this.OuterClassList.Add(outerClassObject);
            this.PopulateInnerClassList();
        }
        private void PopulateInnerClassList()
        {
            this.InnerClassList = new List<InnerClass>();
            foreach (var item in this.OuterClassList)
            {
                this.InnerClassList.Add(item.InnerObject);
            }
        }
    }
