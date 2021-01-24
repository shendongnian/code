    public class Logger
    {
        public static void Log(object message)
        {
            if (message.GetType() == typeof(Vector3))
            {
                Vector3 vec = (Vector3)message;
                string res = String.Format("({0}, {1}, {2})", vec.x, vec.y, vec.z);
                Debug.Log(res);
            }
            else
            {
                Debug.Log(message);
            }
        }
    }
