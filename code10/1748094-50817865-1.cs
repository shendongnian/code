    #if UNITY_EDITOR
    using System.Diagnostics;
    using System.Text;
    #endif
    
    public class BulletController : MonoBehaviour
    {
        private Vector3 _direction = Vector3.None;
        public Vector3 direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
    #if UNITY_EDITOR
                StringBuilder sb = new StringBuilder ( "direction updated.\n" );
                StackTrace trace = new StackTrace ( true );
                for ( int i = 0; i < trace.FrameCount; i++ ) // You could use "for ( int i = 1; ... ", after you get the hang of it.
                {
                    StackFrame sf = trace.GetFrame ( i );
                    sb.AppendLine ( $"[{value}] {sf.GetMethod ( )} : {sf.GetFileName ( )} ({sf.GetFileLineNumber ( )})" );
                }
                UnityEngine.Debug.Log ( sb.ToString ( ) );
    #endif
            }
        }
    }
