            var myClass =  new MyClass();
            // Do whatever with it.
            // Then store it
            Application.Current.Resources.Add("CachedInstance", myClass);
            // Get it back out.
            var classLaterOn = Application.Current.Resources["CachedInstance"] as MyClass;
