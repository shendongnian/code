            ///////////////////////////////////////////////////////////////////////////////////////////
        /// IsNotKeyBounce - determines if a key is bouncing and therefore not valid within
        ///    a certain "delay" period
        ///////////////////////////////////////////////////////////////////////////////////////////
        private bool IsNotKeyBounce(Keys thekey, double delay)
        {
            bool OKtoPress = true;
            if (_keyBounceDict.ContainsKey(thekey))
            {
                TimeSpan ts = DateTime.Now - _keyBounceDict[thekey];
                if (ts.TotalMilliseconds < _tsKeyBounceTiming)
                {
                    OKtoPress = false;
                }
                else
                {
                    DateTime dummy;
                    _keyBounceDict.TryRemove(thekey, out dummy);
                }
            }
            else
            {
                _keyBounceDict.AddOrUpdate(thekey, DateTime.Now, (key, oldValue) => oldValue);
            }
            return OKtoPress;
        }
