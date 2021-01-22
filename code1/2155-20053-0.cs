    Class a<T>{
        private void checkWetherTypeIsOK()
        {
            if (T is int || T is float //|| ... any other types you want to be allowed){
                return true;
            }
            else {
                throw new exception();
            }
        }
        public static a(){
            ccheckWetherTypeIsOK();
        }
    }
