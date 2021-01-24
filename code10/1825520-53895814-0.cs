    using GalaSoft.MvvmLight;
    using System;
    using System.Collections.Generic;
    
    namespace GalaxyCreator.Model.Json
    {
        public class Job : ObservableObject
        {
            private String _id;
            public String Id
            {
                get { return _id; }
                set
                {
                    Set(ref _id, value);
                }
            }
        }
    }
