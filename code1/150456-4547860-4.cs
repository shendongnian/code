        Imports System
        Imports System.IO
        If Not My.Settings.IUpgraded Then 'Upgrade application settings from previous version
            My.Settings.Upgrade()
            'The following routine is only relevant upgrading version 1.2.0.0
            If Not My.Settings.IUpgraded Then 'enumerate AppData folder to find previous versions
                Dim lastVersion As String = "1.2.0.0" 'version to upgrade settings from
                Dim config_initial As System.Configuration.Configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal)
                Dim fpath As String = config_initial.FilePath
                For x = 1 To 3 'recurse backwards to find root CompanyName folder
                    fpath = fpath.Substring(0, InStrRev(fpath, "\", Len(fpath) - 1))
                Next
                fpath = fpath.Substring(0, Len(fpath) - 1) 'remove trailing backslash
                Dim latestConfig As FileInfo 'If not set then no previous info found
                Dim di As DirectoryInfo = New DirectoryInfo(fpath)
                If di.Exists Then
                    For Each diSubDir As DirectoryInfo In di.GetDirectories(lastVersion, SearchOption.AllDirectories)
                        If InStr(diSubDir.FullName, ".vshost") = 0 Then 'don't find VS runtime copies
                            Dim files() As FileInfo = diSubDir.GetFiles("user.config", SearchOption.TopDirectoryOnly)
                            For Each File As FileInfo In files
                                Try
                                    If File.LastWriteTime > latestConfig.LastWriteTime Then
                                        latestConfig = File
                                    End If
                                Catch
                                    latestConfig = File
                                End Try
                            Next
                        End If
                    Next
                End If
                Try
                    If latestConfig.Exists Then
                        Dim newPath As String = config_initial.FilePath
                        newPath = newPath.Substring(0, InStrRev(newPath, "\", Len(newPath) - 1))
                        newPath = newPath.Substring(0, InStrRev(newPath, "\", Len(newPath) - 1))
                        newPath &= lastVersion
                        If Directory.Exists(newPath) = False Then
                            Directory.CreateDirectory(newPath)
                        End If
                        latestConfig.CopyTo(newPath & "\user.config")
                        My.Settings.Upgrade() 'Try upgrading again now old user.config exists in correct place
                    End If
                Catch : End Try
            End If
            My.Settings.IUpgraded = True 'Always set this to avoid potential upgrade loop
            My.Settings.Save()
        End If
