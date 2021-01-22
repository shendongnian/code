    // ReSharper disable InconsistentNaming
    // ReSharper disable PartialMethodWithSinglePart
    // ReSharper disable PartialTypeWithSinglePart
    namespace SO
    {
        using System;
        using System.ComponentModel;
        
        // ------------------------------------------------------------------------
        /// <summary>
        /// class A (implements INotifyPropertyChanged)
        /// </summary>
        public partial class A : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged (string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) 
                {
                    handler (this, new PropertyChangedEventArgs (name));
                }
            }
            // --------------------------------------------------------------------
            /// <summary>
            /// Gets or sets property Id (int)
            /// </summary>
            public int Id
            { 
                get { return _Id; } 
                set 
                { 
                    if (_Id == value) 
                    { 
                        return; 
                    } 
                    _Id = value; 
                    Change_Id ();
                    OnPropertyChanged("Id");  
 
                } 
            } 
            // --------------------------------------------------------------------
            int _Id; 
            // --------------------------------------------------------------------
            partial void Change_Id ();
            // --------------------------------------------------------------------
            // --------------------------------------------------------------------
            /// <summary>
            /// Gets or sets property Name (string)
            /// </summary>
            public string Name
            { 
                get { return _Name; } 
                set 
                { 
                    if (_Name == value) 
                    { 
                        return; 
                    } 
                    _Name = value; 
                    Change_Name ();
                    OnPropertyChanged("Name");  
 
                } 
            } 
            // --------------------------------------------------------------------
            string _Name; 
            // --------------------------------------------------------------------
            partial void Change_Name ();
            // --------------------------------------------------------------------
            // --------------------------------------------------------------------
            /// <summary>
            /// Gets or sets property FirstB (B)
            /// </summary>
            public B FirstB
            { 
                get { return _FirstB; } 
                set 
                { 
                    if (_FirstB == value) 
                    { 
                        return; 
                    } 
                    if (_FirstB != null) 
                    { 
                        _FirstB.PropertyChanged -= FirstB_Listener;
                    } 
 
                    _FirstB = value; 
 
                    if (_FirstB != null)  
                    {
                        _FirstB.PropertyChanged += FirstB_Listener; 
                    }
                    Change_FirstB ();
                    OnPropertyChanged("FirstB");  
 
                } 
            } 
            // --------------------------------------------------------------------
            B _FirstB; 
            // --------------------------------------------------------------------
            partial void Change_FirstB ();
            // --------------------------------------------------------------------
            void FirstB_Listener (object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine (
                    "Instance of A detected a change of FirstB.{0}", 
                    e.PropertyName
                    );
                Change_FirstB ();
            }
            // --------------------------------------------------------------------
            // --------------------------------------------------------------------
            /// <summary>
            /// Gets or sets property SecondB (B)
            /// </summary>
            public B SecondB
            { 
                get { return _SecondB; } 
                set 
                { 
                    if (_SecondB == value) 
                    { 
                        return; 
                    } 
                    if (_SecondB != null) 
                    { 
                        _SecondB.PropertyChanged -= SecondB_Listener;
                    } 
 
                    _SecondB = value; 
 
                    if (_SecondB != null)  
                    {
                        _SecondB.PropertyChanged += SecondB_Listener; 
                    }
                    Change_SecondB ();
                    OnPropertyChanged("SecondB");  
 
                } 
            } 
            // --------------------------------------------------------------------
            B _SecondB; 
            // --------------------------------------------------------------------
            partial void Change_SecondB ();
            // --------------------------------------------------------------------
            void SecondB_Listener (object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine (
                    "Instance of A detected a change of SecondB.{0}", 
                    e.PropertyName
                    );
                Change_SecondB ();
            }
            // --------------------------------------------------------------------
            // --------------------------------------------------------------------
            /// <summary>
            /// Gets or sets property ThirdB (B)
            /// </summary>
            public B ThirdB
            { 
                get { return _ThirdB; } 
                set 
                { 
                    if (_ThirdB == value) 
                    { 
                        return; 
                    } 
                    if (_ThirdB != null) 
                    { 
                        _ThirdB.PropertyChanged -= ThirdB_Listener;
                    } 
 
                    _ThirdB = value; 
 
                    if (_ThirdB != null)  
                    {
                        _ThirdB.PropertyChanged += ThirdB_Listener; 
                    }
                    Change_ThirdB ();
                    OnPropertyChanged("ThirdB");  
 
                } 
            } 
            // --------------------------------------------------------------------
            B _ThirdB; 
            // --------------------------------------------------------------------
            partial void Change_ThirdB ();
            // --------------------------------------------------------------------
            void ThirdB_Listener (object sender, PropertyChangedEventArgs e)
            {
                Console.WriteLine (
                    "Instance of A detected a change of ThirdB.{0}", 
                    e.PropertyName
                    );
                Change_ThirdB ();
            }
            // --------------------------------------------------------------------
        }
        // ------------------------------------------------------------------------
        
        // ------------------------------------------------------------------------
        /// <summary>
        /// class B (implements INotifyPropertyChanged)
        /// </summary>
        public partial class B : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged (string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) 
                {
                    handler (this, new PropertyChangedEventArgs (name));
                }
            }
            // --------------------------------------------------------------------
            /// <summary>
            /// Gets or sets property Id (int)
            /// </summary>
            public int Id
            { 
                get { return _Id; } 
                set 
                { 
                    if (_Id == value) 
                    { 
                        return; 
                    } 
                    _Id = value; 
                    Change_Id ();
                    OnPropertyChanged("Id");  
 
                } 
            } 
            // --------------------------------------------------------------------
            int _Id; 
            // --------------------------------------------------------------------
            partial void Change_Id ();
            // --------------------------------------------------------------------
            // --------------------------------------------------------------------
            /// <summary>
            /// Gets or sets property Name (string)
            /// </summary>
            public string Name
            { 
                get { return _Name; } 
                set 
                { 
                    if (_Name == value) 
                    { 
                        return; 
                    } 
                    _Name = value; 
                    Change_Name ();
                    OnPropertyChanged("Name");  
 
                } 
            } 
            // --------------------------------------------------------------------
            string _Name; 
            // --------------------------------------------------------------------
            partial void Change_Name ();
            // --------------------------------------------------------------------
        }
        // ------------------------------------------------------------------------
    }
