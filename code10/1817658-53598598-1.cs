      public object get_AD_property(string attribute_)
        {
            try
            {
                using (this.AD_object = new DirectoryEntry(this.path_))
                {
                    return this.AD_object.Properties[attribute_].Value;
                }
            }
            catch (ArgumentNullException x)
            {
                return new ArgumentNullException(x.Message, x);
            }
        }
