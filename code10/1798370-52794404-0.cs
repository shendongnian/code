    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using UnityEditor;
    using UnityEngine;
    using Debug = UnityEngine.Debug;
    
    public class RoEditorWindow : EditorWindow
    {
        private static RoEditorWindow win;
    
        [MenuItem("Window/Ro Editor Window %g")]
        static void St()
        {
            if (!win)
            {
                win = ScriptableObject.CreateInstance<RoEditorWindow>();
            }
    
            Debug.Log("Run Focus");
            win.ShowAuxWindow();
            EditorWindow.FocusWindowIfItsOpen<RoEditorWindow>();
            var title = $"Ro Editor Windows in Process {Process.GetCurrentProcess().Id}";
            win.SetTitle(title);
            new Thread(() =>
            {
                var startAt = DateTime.Now;
                while (true)
                {
                    try
                    {
                        var cmd = $"xdotool search --name --onlyvisible --limit  1 \"{title}\"";
                        var wid = Sh(cmd);
                        if (wid != "")
                        {
                            Sh($"xdotool windowactivate {wid}");
                            break;
                        }
                    }
                    catch (SystemException e)
                    {
                    }
    
                    if ((DateTime.Now - startAt).TotalSeconds > 5)
                    {
                        break;
                    }
                }
            }).Start();
        }
    
        public static string Sh(string cmd)
        {
            string output = "";
            string error = string.Empty;
    
            var psi = new ProcessStartInfo("/bin/bash", $"-c '{cmd}'");
    
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            Process p = Process.Start(psi);
            using (System.IO.StreamReader myOutput = p.StandardOutput)
            {
                output = myOutput.ReadToEnd();
            }
    
            using (System.IO.StreamReader myError = p.StandardError)
            {
                error = myError.ReadToEnd();
            }
    
            if (error != "")
            {
                throw new SystemException($"err cmd: {cmd}\n{error}");
            }
    
            return output;
        }
    
    
        public void SetTitle(string v)
        {
            titleContent = new GUIContent(v);
        }
    
        private void OnGUI()
        {
            EditorGUILayout.TextField("input", "");
            if (Event.current.isKey)
            {
                Debug.Log("key is pressed");
            }
        }
    }
