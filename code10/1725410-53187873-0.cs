      /// ================================
        /// Checks if the object of type T is null or not, 
        /// If object is null, prints a log message if 'enableLog' set to 'true'
        /// https://answers.unity.com/questions/238229/debugconsole-console-clicking.html
        /// ================================
        public static bool IsNull<T>( this T classType, bool enableLog = true, MonoBehaviour monoInstance = null) where T : class
		{
			if(classType == null)
			{	if(enableLog)
				{   //if(classType.GetType().IsSubclassOf(typeof(MonoBehaviour)))
					var frame = new System.Diagnostics.StackTrace(true).GetFrame(1);
                    string fileName = FormatFileName(frame.GetFileName());
                    int lineNum = frame.GetFileLineNumber();
                    int colomn = frame.GetFileColumnNumber();
                    string msg = "WARNING:- The instance of type " + typeof(T) + " is null!"
                        + "\nFILE: " + fileName + " LINE: " + lineNum;
                    //Debug.LogWarning(msg, (UnityEngine.Object)monoInstance.gameObject);
                    var mUnityLog = typeof(UnityEngine.Debug).GetMethod("LogPlayerBuildError", BindingFlags.NonPublic | BindingFlags.Static);
                    mUnityLog.Invoke(null, new object[] { msg, fileName, lineNum, colomn });
                }
				return true;
			}
			return false;
		} 
