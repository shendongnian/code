    using System;
    using System.Runtime.InteropServices;
    
    namespace Stackoverflow
    {
        class TimeZoneFunctionality
        {
            /// <summary>
            /// [Win32 API call]
            /// The GetTimeZoneInformation function retrieves the current time-zone parameters.
            /// These parameters control the translations between Coordinated Universal Time (UTC)
            /// and local time.
            /// </summary>
            /// <param name="lpTimeZoneInformation">[out] Pointer to a TIME_ZONE_INFORMATION structure to receive the current time-zone parameters.</param>
            /// <returns>
            /// If the function succeeds, the return value is one of the following values.
            /// <list type="table">
            /// <listheader>
            /// <term>Return code/value</term>
            /// <description>Description</description>
            /// </listheader>
            /// <item>
            /// <term>TIME_ZONE_ID_UNKNOWN == 0</term>
            /// <description>
            /// The system cannot determine the current time zone. This error is also returned if you call the SetTimeZoneInformation function and supply the bias values but no transition dates.
            /// This value is returned if daylight saving time is not used in the current time zone, because there are no transition dates.
            /// </description>
            /// </item>
            /// <item>
            /// <term>TIME_ZONE_ID_STANDARD == 1</term>
            /// <description>
            /// The system is operating in the range covered by the StandardDate member of the TIME_ZONE_INFORMATION structure.
            /// </description>
            /// </item>
            /// <item>
            /// <term>TIME_ZONE_ID_DAYLIGHT == 2</term>
            /// <description>
            /// The system is operating in the range covered by the DaylightDate member of the TIME_ZONE_INFORMATION structure.
            /// </description>
            /// </item>
            /// </list>
            /// If the function fails, the return value is TIME_ZONE_ID_INVALID. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport( "kernel32.dll", CharSet = CharSet.Auto )]
            private static extern int GetTimeZoneInformation( out TimeZoneInformation lpTimeZoneInformation );
    
            /// <summary>
            /// [Win32 API call]
            /// The SetTimeZoneInformation function sets the current time-zone parameters.
            /// These parameters control translations from Coordinated Universal Time (UTC)
            /// to local time.
            /// </summary>
            /// <param name="lpTimeZoneInformation">[in] Pointer to a TIME_ZONE_INFORMATION structure that contains the time-zone parameters to set.</param>
            /// <returns>
            /// If the function succeeds, the return value is nonzero.
            /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
            /// </returns>
            [DllImport( "kernel32.dll", CharSet = CharSet.Auto )]
            private static extern bool SetTimeZoneInformation( [In] ref TimeZoneInformation lpTimeZoneInformation );
    
            /// <summary>
            /// The SystemTime structure represents a date and time using individual members
            /// for the month, day, year, weekday, hour, minute, second, and millisecond.
            /// </summary>
            [StructLayoutAttribute( LayoutKind.Sequential )]
            public struct SystemTime
            {
                public short year;
                public short month;
                public short dayOfWeek;
                public short day;
                public short hour;
                public short minute;
                public short second;
                public short milliseconds;
            }
    
            /// <summary>
            /// The TimeZoneInformation structure specifies information specific to the time zone.
            /// </summary>
            [StructLayout( LayoutKind.Sequential, CharSet = CharSet.Unicode )]
            public struct TimeZoneInformation
            {
                /// <summary>
                /// Current bias for local time translation on this computer, in minutes. The bias is the difference, in minutes, between Coordinated Universal Time (UTC) and local time. All translations between UTC and local time are based on the following formula:
                /// <para>UTC = local time + bias</para>
                /// <para>This member is required.</para>
                /// </summary>
                public int bias;
                /// <summary>
                /// Pointer to a null-terminated string associated with standard time. For example, "EST" could indicate Eastern Standard Time. The string will be returned unchanged by the GetTimeZoneInformation function. This string can be empty.
                /// </summary>
                [MarshalAs( UnmanagedType.ByValTStr, SizeConst = 32 )]
                public string standardName;
                /// <summary>
                /// A SystemTime structure that contains a date and local time when the transition from daylight saving time to standard time occurs on this operating system. If the time zone does not support daylight saving time or if the caller needs to disable daylight saving time, the wMonth member in the SystemTime structure must be zero. If this date is specified, the DaylightDate value in the TimeZoneInformation structure must also be specified. Otherwise, the system assumes the time zone data is invalid and no changes will be applied.
                /// <para>To select the correct day in the month, set the wYear member to zero, the wHour and wMinute members to the transition time, the wDayOfWeek member to the appropriate weekday, and the wDay member to indicate the occurence of the day of the week within the month (first through fifth).</para>
                /// <para>Using this notation, specify the 2:00a.m. on the first Sunday in April as follows: wHour = 2, wMonth = 4, wDayOfWeek = 0, wDay = 1. Specify 2:00a.m. on the last Thursday in October as follows: wHour = 2, wMonth = 10, wDayOfWeek = 4, wDay = 5.</para>
                /// </summary>
                public SystemTime standardDate;
                /// <summary>
                /// Bias value to be used during local time translations that occur during standard time. This member is ignored if a value for the StandardDate member is not supplied.
                /// <para>This value is added to the value of the Bias member to form the bias used during standard time. In most time zones, the value of this member is zero.</para>
                /// </summary>
                public int standardBias;
                /// <summary>
                /// Pointer to a null-terminated string associated with daylight saving time. For example, "PDT" could indicate Pacific Daylight Time. The string will be returned unchanged by the GetTimeZoneInformation function. This string can be empty.
                /// </summary>
                [MarshalAs( UnmanagedType.ByValTStr, SizeConst = 32 )]
                public string daylightName;
                /// <summary>
                /// A SystemTime structure that contains a date and local time when the transition from standard time to daylight saving time occurs on this operating system. If the time zone does not support daylight saving time or if the caller needs to disable daylight saving time, the wMonth member in the SystemTime structure must be zero. If this date is specified, the StandardDate value in the TimeZoneInformation structure must also be specified. Otherwise, the system assumes the time zone data is invalid and no changes will be applied.
                /// <para>To select the correct day in the month, set the wYear member to zero, the wHour and wMinute members to the transition time, the wDayOfWeek member to the appropriate weekday, and the wDay member to indicate the occurence of the day of the week within the month (first through fifth).</para>
                /// </summary>
                public SystemTime daylightDate;
                /// <summary>
                /// Bias value to be used during local time translations that occur during daylight saving time. This member is ignored if a value for the DaylightDate member is not supplied.
                /// <para>This value is added to the value of the Bias member to form the bias used during daylight saving time. In most time zones, the value of this member is –60.</para>
                /// </summary>
                public int daylightBias;
            }
    
            /// <summary>
            /// Sets new time-zone information for the local system.
            /// </summary>
            /// <param name="tzi">Struct containing the time-zone parameters to set.</param>
            public static void SetTimeZone( TimeZoneInformation tzi )
            {
                // set local system timezone
                SetTimeZoneInformation( ref tzi );
            }
    
            /// <summary>
            /// Gets current timezone information for the local system.
            /// </summary>
            /// <returns>Struct containing the current time-zone parameters.</returns>
            public static TimeZoneInformation GetTimeZone()
            {
                // create struct instance
                TimeZoneInformation tzi;
    
                // retrieve timezone info
                int currentTimeZone = GetTimeZoneInformation( out tzi );
    
                return tzi;
            }
    
            /// <summary>
            /// Oversimplyfied method to test  the GetTimeZone functionality
            /// </summary>
            /// <param name="args">the usual stuff</param>
            static void Main( string[] args )
            {
                TimeZoneInformation timeZoneInformation = GetTimeZone();
    
                return;
            }
        }
    }
