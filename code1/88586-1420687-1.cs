        /// <internalonly/>
        /// <devdoc>
        /// </devdoc>
        [Browsable(false)] 
        public override ISite Site {
            get { 
                return base.Site; 
            }
            set { 
                base.Site = value;
                // set EnableRaisingEvents to true at design time so the user
                // doesn't have to manually. We can't do this in 
                // the constructor because in code it should
                // default to false. 
                if (Site != null && Site.DesignMode) 
                    EnableRaisingEvents = true;
            } 
        }
