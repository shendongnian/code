    private void AssertPropertyChanged<T>(T instance, Action<T> actionPropertySetter, string expectedPropertyName) where T : INotifyPropertyChanged
        {
            string actual = null;
            instance.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                actual = e.PropertyName;
            };
            actionPropertySetter.Invoke(instance);
            Assert.IsNotNull(actual);
            Assert.AreEqual(propertyName, actual);
        }
