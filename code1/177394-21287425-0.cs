    /// <summary>
    /// Class ThreadName.
    /// </summary>
    public class ThreadName
    {
        /// <summary>
        /// Updates the name of the thread.
        /// </summary>
        /// <param name="strName" type="System.String">Name of the string.</param>
        /// <param name="paramObjects" type="System.Object[]">The parameter objects.</param>
        /// <remarks>if strName is null, just reset the name do not assign a new one</remarks>
        static public void UpdateThreadName(string strName, params object[] paramObjects)
        {
            //
            // if we already have a name reset it
            //
            if(null != Thread.CurrentThread.Name)
            {
                ResetThreadName(Thread.CurrentThread);                
            }
            if(null != strName)
            {
                StringBuilder   sbVar   = new StringBuilder();
                sbVar.AppendFormat(strName, paramObjects);
                sbVar.AppendFormat("_{0}", DateTime.Now.ToString("yyyyMMdd-HH:mm:ss:ffff"));
                Thread.CurrentThread.Name = sbVar.ToString();
            }
        }
        /// <summary>
        /// Reset the name of the set thread.
        /// </summary>
        /// <param name="thread" type="Thread">The thread.</param>
        /// <exception cref="System.NullReferenceException">Thread cannot be null</exception>
        static private void ResetThreadName(Thread thread)
        {
            if(null == thread) throw new System.NullReferenceException("Thread cannot be null");
            lock(thread)
            {
                //
                // This is a private member of Thread, if they ever change the name this will not work
                //
                var field = thread.GetType().GetField("m_Name", BindingFlags.Instance | BindingFlags.NonPublic);
                if(null != field)
                {
                    //
                    // Change the Name to null (nothing)
                    //
                    field.SetValue(thread, null);
                    
                    //
                    // This 'extra' null set notifies Visual Studio about the change
                    //
                    thread.Name = null;
                }
            } 
        }
    }
