    using System;
    using System.Diagnostics;
    
    public class Program
    {
        public static void Main()
        {
            MyObject myObject = new MyObject();
            Vector3 vector3 = new Vector3(1, 1, 1);
            myObject.p_pos = vector3;
            myObject.p_pos.X = 5;
            Console.ReadLine();
        }
    }
    
    
    public class Vector3
    {
        public Vector3(double x, double y, double z)
        {
            X = x; Y = y; Z = z;
        }
    
        private double _x;
        private double _y;
        private double _z;
    
        public double X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        public double Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
    
        public event EventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(EventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
    
    public class MyObject
    {
        private Vector3 _p_pos = null;
    
        public Vector3 p_pos { get
            {
                return _p_pos;
            }
            set
            {
                if (_p_pos != null)
                    _p_pos.PropertyChanged-= _p_pos_PropertyChanged;
                _p_pos = value;
                _p_pos.PropertyChanged += _p_pos_PropertyChanged;
    
            }
        }
    
        private void _p_pos_PropertyChanged(object sender, EventArgs e)
        {
            Console.Write("_p_pos_PropertyChanged");
        }
    }
