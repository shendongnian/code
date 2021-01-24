     public Boolean set_AD_property(string attribute_, string new_value)
        {
            this.AD_object = new DirectoryEntry(this.path_);
            this.AD_object.Properties[attribute_].Value = new_value;
            try
            {
                this.AD_object.CommitChanges();
                this.AD_object.Close();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
