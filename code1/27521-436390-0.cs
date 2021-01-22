    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.InteropServices;
    namespace OpenNETCF.Globalization
    {
        public class CultureInfoHelper
        {
            private delegate int EnumLocalesHandler(string lpLocaleString);
            private static EnumLocalesHandler m_localesDelegate;
            private static List<CultureInfo> m_cultures;
            private static int EnumLocalesProc(string locale)
            {
                try
                {
                    m_cultures.Add(CultureInfo.GetCultureInfo(
                        int.Parse(locale, NumberStyles.HexNumber)));
                }
                catch
                {
                    // failed for this locale - ignore and continue
                }
                return 1;
            }
            public static CultureInfo[] GetCultures()
            {
                if (m_localesDelegate == null)
                {
                    m_cultures = new List<CultureInfo>();
                    m_localesDelegate = new EnumLocalesHandler(EnumLocalesProc);
                    IntPtr fnPtr = Marshal.GetFunctionPointerForDelegate(
                        m_localesDelegate);
                    int success = EnumSystemLocales(fnPtr, LCID_INSTALLED);
                }
                return m_cultures.ToArray();
            }
            private const int LCID_INSTALLED = 0x01;
            private const int LCID_SUPPORTED = 0x02;
            [DllImport("coredll", SetLastError = true)]
            private static extern int EnumSystemLocales(
                IntPtr lpLocaleEnumProc, uint dwFlags);
        }
    }
