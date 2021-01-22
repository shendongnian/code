    using Microsoft.Win32;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    public static class Helper
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int ExtractIconEx(string lpszFile, int nIconIndex, IntPtr[] phIconLarge, IntPtr[] phIconSmall, int nIcons);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int DestroyIcon(IntPtr hIcon);
        public static string GetFileContentType(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            RegistryKey registryKey = null;
            try
            {
                FileInfo fileInfo = new FileInfo(fileName);
                if (string.IsNullOrEmpty(fileInfo.Extension))
                {
                    return string.Empty;
                }
                string extension = fileInfo.Extension.ToLowerInvariant();
                registryKey = Registry.ClassesRoot.OpenSubKey(extension);
                if (registryKey == null)
                {
                    return string.Empty;
                }
                object contentTypeObject = registryKey.GetValue("Content Type");
                if (!(contentTypeObject is string))
                {
                    return string.Empty;
                }
                string contentType = (string)contentTypeObject;
                return contentType;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (registryKey != null)
                {
                    registryKey.Close();
                }
            }
        }
        public static string GetFileDescription(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            RegistryKey registryKey1 = null;
            RegistryKey registryKey2 = null;
            try
            {
                FileInfo fileInfo = new FileInfo(fileName);
                if (string.IsNullOrEmpty(fileInfo.Extension))
                {
                    return string.Empty;
                }
                string extension = fileInfo.Extension.ToLowerInvariant();
                registryKey1 = Registry.ClassesRoot.OpenSubKey(extension);
                if (registryKey1 == null)
                {
                    return string.Empty;
                }
                object extensionDefaultObject = registryKey1.GetValue(null);
                if (!(extensionDefaultObject is string))
                {
                    return string.Empty;
                }
                string extensionDefaultValue = (string)extensionDefaultObject;
                registryKey2 = Registry.ClassesRoot.OpenSubKey(extensionDefaultValue);
                if (registryKey2 == null)
                {
                    return string.Empty;
                }
                object fileDescriptionObject = registryKey2.GetValue(null);
                if (!(fileDescriptionObject is string))
                {
                    return string.Empty;
                }
                string fileDescription = (string)fileDescriptionObject;
                return fileDescription;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (registryKey2 != null)
                {
                    registryKey2.Close();
                }
                if (registryKey1 != null)
                {
                    registryKey1.Close();
                }
            }
        }
        public static void GetFileIcons(string fileName, out Icon smallIcon, out Icon largeIcon)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            smallIcon = null;
            largeIcon = null;
            RegistryKey registryKey1 = null;
            RegistryKey registryKey2 = null;
            try
            {
                FileInfo fileInfo = new FileInfo(fileName);
                if (string.IsNullOrEmpty(fileInfo.Extension))
                {
                    return;
                }
                string extension = fileInfo.Extension.ToLowerInvariant();
                registryKey1 = Registry.ClassesRoot.OpenSubKey(extension);
                if (registryKey1 == null)
                {
                    return;
                }
                object extensionDefaultObject = registryKey1.GetValue(null);
                if (!(extensionDefaultObject is string))
                {
                    return;
                }
                string defaultIconKeyName = string.Format("{0}\\DefaultIcon", extensionDefaultObject);
                registryKey2 = Registry.ClassesRoot.OpenSubKey(defaultIconKeyName);
                if (registryKey2 == null)
                {
                    return;
                }
                object defaultIconPathObject = registryKey2.GetValue(null);
                if (!(defaultIconPathObject is string))
                {
                    return;
                }
                string defaultIconPath = (string)defaultIconPathObject;
                if (string.IsNullOrWhiteSpace(defaultIconPath))
                {
                    return;
                }
                string iconfileName = null;
                int iconIndex = 0;
                int commaIndex = defaultIconPath.IndexOf(",");
                if (commaIndex > 0)
                {
                    iconfileName = defaultIconPath.Substring(0, commaIndex);
                    string iconIndexString = defaultIconPath.Substring(commaIndex + 1);
                    if (!int.TryParse(iconIndexString, out iconIndex))
                    {
                        iconIndex = 0;
                    }
                }
                else
                {
                    iconfileName = defaultIconPath;
                    iconIndex = 0;
                }
                IntPtr[] phiconSmall = new IntPtr[1] { IntPtr.Zero };
                IntPtr[] phiconLarge = new IntPtr[1] { IntPtr.Zero };
                int readIconCount = ExtractIconEx(iconfileName, iconIndex, phiconLarge, phiconSmall, 1);
                if (readIconCount < 0)
                {
                    return;
                }
                if (phiconSmall[0] != IntPtr.Zero)
                {
                    smallIcon = (Icon)Icon.FromHandle(phiconSmall[0]).Clone();
                    DestroyIcon(phiconSmall[0]);
                }
                if (phiconLarge[0] != IntPtr.Zero)
                {
                    largeIcon = (Icon)Icon.FromHandle(phiconLarge[0]).Clone();
                    DestroyIcon(phiconLarge[0]);
                }
                return;
            }
            finally
            {
                if (registryKey2 != null)
                {
                    registryKey2.Close();
                }
                if (registryKey1 != null)
                {
                    registryKey1.Close();
                }
            }
        }
    }
