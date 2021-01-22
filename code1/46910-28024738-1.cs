      public class DerivedClass: BaseClass
        { 
            public DerivedClass(BaseClass baseModel)
            {
                this.CopyProperties(baseModel);
            }
        }
