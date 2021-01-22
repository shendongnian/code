            catch (TargetInvocationException tiex)
            {
                // Get the _remoteStackTraceString of the Exception class
                FieldInfo remoteStackTraceString = typeof(Exception)
                    .GetField("_remoteStackTraceString",
                        BindingFlags.Instance | BindingFlags.NonPublic); // MS.Net
                if (remoteStackTraceString == null)
                    remoteStackTraceString = typeof(Exception)
                    .GetField("remote_stack_trace",
                        BindingFlags.Instance | BindingFlags.NonPublic); // Mono
                // Set the InnerException._remoteStackTraceString
                // to the current InnerException.StackTrace
                remoteStackTraceString.SetValue(tiex.InnerException,
                    tiex.InnerException.StackTrace + Environment.NewLine);
                // Throw the new exception
                throw tiex.InnerException;
            }
