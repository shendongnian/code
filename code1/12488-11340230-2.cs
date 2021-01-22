        class C1
        {
            private void MyMethod(double x, int i)
            {
                // some code
            }
            // the friend class would be able to call myMethod
            public void MyMethod(FriendClass F, double x, int i)
            {
                this.MyMethod(x, i);
            }
            //my friend class wouldn't have access to this method 
            private void MyVeryPrivateMethod(string s)
            {
                // some code
            }
        }
        class FriendClass
        {
            public void SomeMethod()
            {
                C1 c = new C1();
                c.MyMethod(this, 5.5, 3);
            }
        }
