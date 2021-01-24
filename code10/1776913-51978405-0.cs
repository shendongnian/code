        [InitializeOnLoad]
        public class ChangeUnityEditorWindowTitle : MonoBehaviour
        {
            // unity editor will auto reset editor title in many cases
            static ChangeUnityEditorWindowTitle()
            {
                EditorApplication.update += ChangeTitleWhenSceneOnRuntime;
            }
    
            private static DateTime lastTime;
    
            private static void ChangeTitleWhenSceneOnRuntime()
            {
                if ((DateTime.Now - lastTime).TotalSeconds > 1)
                {
                    lastTime = DateTime.Now;
                    ChangeTitle();
                }
            }
    
            static string GetCurEditorTitle()
            {
                if (curWid != null)
                {
                    return Shsu($"xdotool getwindowname {curWid}").Trim();
                }
    
                return null;
            }
    
            private static string _curWid;
    
            private static string curWid
            {
                get
                {
                    if (_curWid == null)
                    {
                        var cmd = $"xdotool search --onlyvisible --name \"Unity - Unity.*- {GetProjectName()} -\"";
    //            var cmd = $"xdotool search --onlyvisible --pid {pid}";
                        _curWid = Shsu(cmd).Split("\n")[0].Trim();
                    }
    
                    return _curWid;
                }
            }
    
            private static string GetProjectName()
            {
                return RoFile.Basename(EditorUtil.GetProject());
            }
    
            private static string newTitle;
    
            [MenuItem("Ro/Change Unity Editor Window Title")]
            static void ChangeTitle()
            {
                var title = GetCurEditorTitle();
                var pjName = GetProjectName();
                if (title.IsMatch(@"Unity - Unity"))
                {
                    if (!title.IsMatch($"^{pjName}"))
                    {
                        if (newTitle == null)
                        {
                            newTitle = $"{pjName} - {title}";
                        }
    
                        Debug.Log($"Set unity editor title as \"{newTitle}\" ");
                        Shsu($"xdotool set_window --name \"{newTitle}\" {curWid}");
                    }
                }
            }
        }
