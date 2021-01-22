        /// <summary>
        /// Sets the value of the constructor argument
        /// </summary>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        public T EqualTo(object propertyValue)
        {
            if(propertyValue.GetType().IsSimple())
                _instance.SetProperty(_propertyName, propertyValue.ToString());
            else
            {
                _instance.SetChild(_propertyName,new LiteralInstance(propertyValue));
            }
            return (T) _instance;
        }
