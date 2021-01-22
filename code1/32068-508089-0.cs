    public class BusinessLogic {
    
        private BusinessLogicSubClass mChild;
    
        public BusinessLogic() {
        }
    
        public BusinessLogicSubClass Child {
            get {
                return mChild ?? (mChild = new BusinessLogicSubClass(this));
            }
        }
    
        public class BusinessLogicSubClass {
            public BusinessLogicSubClass(BusinessLogic parent) {
            }
        }
    }
