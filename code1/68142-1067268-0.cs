    public struct Vector3
    {
        public Vector3(float X, float Y, float Z, VectorListener listener)
        {
            m_x = X;
            m_y = Y;
            m_z = Z;
            m_listener = listener;
        }
        private VectorListener m_listener;
        private float m_x;
        private float m_y;
        private float m_z;
        public float X
        {
            get{return m_x;}
            set{ m_x = value; m_listener.SetVector(this);}
        }
        public float Y
        {
            get { return m_y; }
            set { m_y = value; m_listener.SetVector(this); }
        }
        public float Z
        {
            get { return m_z; }
            set { m_z = value; m_listener.SetVector(this); }
        }
    }
    public interface VectorListener
    {
        void SetVector(Vector3 vec);
    }
    public class Transform : VectorListener
    {
        private bool m_receivedUpdate;
        public Vector3 MyVector { get{return new Vector3(1.0f, 1.0f, 1.0f, this);} }
        public void SetVector(Vector3 vec)
        {
            ReceivedUpdate = true;
        }
        public bool ReceivedUpdate { get; set; }
    }
        // and the test... test class omitted for brevity
        [TestMethod]
        public void TestMethod1()
        {
            Transform transform = new Transform();
            Assert.IsFalse(transform.ReceivedUpdate);
            
            // the following won't compile
            //transform.MyVector.X = 3.0f;
            
            // but this will work
            Vector3 vec = transform.MyVector;
            vec.X = 3.0f;
            Assert.IsTrue(transform.ReceivedUpdate);
        }
