    static void SomeMethod<T>(T param) where T : class
            {
                dynamic tmp1 = param; //null
                var myProperty = tmp1.SomeProperty;
            }
