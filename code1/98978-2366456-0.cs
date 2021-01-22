       1: /**
       2:  * Modified from code originally found here: http://support.microsoft.com/kb/326201
       3:  **/
       4: #region Usings
       5: using System;
       6: using System.Runtime.InteropServices;
       7:  
       8: #endregion
       9:  
      10: namespace Utilities.Web.WebBrowserHelper
      11: {
      12:     /// <summary>
      13:     /// Class for clearing the cache
      14:     /// </summary>
      15:     public static class WebBrowserHelper
      16:     {
      17:         #region Definitions/DLL Imports
      18:         /// <summary>
      19:         /// For PInvoke: Contains information about an entry in the Internet cache
      20:         /// </summary>
      21:         [StructLayout(LayoutKind.Explicit, Size = 80)]
      22:         public struct INTERNET_CACHE_ENTRY_INFOA
      23:         {
      24:             [FieldOffset(0)]
      25:             public uint dwStructSize;
      26:             [FieldOffset(4)]
      27:             public IntPtr lpszSourceUrlName;
      28:             [FieldOffset(8)]
      29:             public IntPtr lpszLocalFileName;
      30:             [FieldOffset(12)]
      31:             public uint CacheEntryType;
      32:             [FieldOffset(16)]
      33:             public uint dwUseCount;
      34:             [FieldOffset(20)]
      35:             public uint dwHitRate;
      36:             [FieldOffset(24)]
      37:             public uint dwSizeLow;
      38:             [FieldOffset(28)]
      39:             public uint dwSizeHigh;
      40:             [FieldOffset(32)]
      41:             public System.Runtime.InteropServices.ComTypes.FILETIME LastModifiedTime;
      42:             [FieldOffset(40)]
      43:             public System.Runtime.InteropServices.ComTypes.FILETIME ExpireTime;
      44:             [FieldOffset(48)]
      45:             public System.Runtime.InteropServices.ComTypes.FILETIME LastAccessTime;
      46:             [FieldOffset(56)]
      47:             public System.Runtime.InteropServices.ComTypes.FILETIME LastSyncTime;
      48:             [FieldOffset(64)]
      49:             public IntPtr lpHeaderInfo;
      50:             [FieldOffset(68)]
      51:             public uint dwHeaderInfoSize;
      52:             [FieldOffset(72)]
      53:             public IntPtr lpszFileExtension;
      54:             [FieldOffset(76)]
      55:             public uint dwReserved;
      56:             [FieldOffset(76)]
      57:             public uint dwExemptDelta;
      58:         }
      59:  
      60:         // For PInvoke: Initiates the enumeration of the cache groups in the Internet cache
      61:         [DllImport(@"wininet",
      62:             SetLastError = true,
      63:             CharSet = CharSet.Auto,
      64:             EntryPoint = "FindFirstUrlCacheGroup",
      65:             CallingConvention = CallingConvention.StdCall)]
      66:         public static extern IntPtr FindFirstUrlCacheGroup(
      67:             int dwFlags,
      68:             int dwFilter,
      69:             IntPtr lpSearchCondition,
      70:             int dwSearchCondition,
      71:             ref long lpGroupId,
      72:             IntPtr lpReserved);
      73:  
      74:         // For PInvoke: Retrieves the next cache group in a cache group enumeration
      75:         [DllImport(@"wininet",
      76:             SetLastError = true,
      77:             CharSet = CharSet.Auto,
      78:             EntryPoint = "FindNextUrlCacheGroup",
      79:             CallingConvention = CallingConvention.StdCall)]
      80:         public static extern bool FindNextUrlCacheGroup(
      81:             IntPtr hFind,
      82:             ref long lpGroupId,
      83:             IntPtr lpReserved);
      84:  
      85:         // For PInvoke: Releases the specified GROUPID and any associated state in the cache index file
      86:         [DllImport(@"wininet",
      87:             SetLastError = true,
      88:             CharSet = CharSet.Auto,
      89:             EntryPoint = "DeleteUrlCacheGroup",
      90:             CallingConvention = CallingConvention.StdCall)]
      91:         public static extern bool DeleteUrlCacheGroup(
      92:             long GroupId,
      93:             int dwFlags,
      94:             IntPtr lpReserved);
      95:  
      96:         // For PInvoke: Begins the enumeration of the Internet cache
      97:         [DllImport(@"wininet",
      98:             SetLastError = true,
      99:             CharSet = CharSet.Auto,
     100:             EntryPoint = "FindFirstUrlCacheEntryA",
     101:             CallingConvention = CallingConvention.StdCall)]
     102:         public static extern IntPtr FindFirstUrlCacheEntry(
     103:             [MarshalAs(UnmanagedType.LPTStr)] string lpszUrlSearchPattern,
     104:             IntPtr lpFirstCacheEntryInfo,
     105:             ref int lpdwFirstCacheEntryInfoBufferSize);
     106:  
     107:         // For PInvoke: Retrieves the next entry in the Internet cache
     108:         [DllImport(@"wininet",
     109:             SetLastError = true,
     110:             CharSet = CharSet.Auto,
     111:             EntryPoint = "FindNextUrlCacheEntryA",
     112:             CallingConvention = CallingConvention.StdCall)]
     113:         public static extern bool FindNextUrlCacheEntry(
     114:             IntPtr hFind,
     115:             IntPtr lpNextCacheEntryInfo,
     116:             ref int lpdwNextCacheEntryInfoBufferSize);
     117:  
     118:         // For PInvoke: Removes the file that is associated with the source name from the cache, if the file exists
     119:         [DllImport(@"wininet",
     120:             SetLastError = true,
     121:             CharSet = CharSet.Auto,
     122:             EntryPoint = "DeleteUrlCacheEntryA",
     123:             CallingConvention = CallingConvention.StdCall)]
     124:         public static extern bool DeleteUrlCacheEntry(
     125:             IntPtr lpszUrlName);
     126:         #endregion
     127:  
     128:         #region Public Static Functions
     129:  
     130:         /// <summary>
     131:         /// Clears the cache of the web browser
     132:         /// </summary>
     133:         public static void ClearCache()
     134:         {
     135:             // Indicates that all of the cache groups in the user's system should be enumerated
     136:             const int CACHEGROUP_SEARCH_ALL = 0x0;
     137:             // Indicates that all the cache entries that are associated with the cache group
     138:             // should be deleted, unless the entry belongs to another cache group.
     139:             const int CACHEGROUP_FLAG_FLUSHURL_ONDELETE = 0x2;
     140:             // File not found.
     141:             const int ERROR_FILE_NOT_FOUND = 0x2;
     142:             // No more items have been found.
     143:             const int ERROR_NO_MORE_ITEMS = 259;
     144:             // Pointer to a GROUPID variable
     145:             long groupId = 0;
     146:  
     147:             // Local variables
     148:             int cacheEntryInfoBufferSizeInitial = 0;
     149:             int cacheEntryInfoBufferSize = 0;
     150:             IntPtr cacheEntryInfoBuffer = IntPtr.Zero;
     151:             INTERNET_CACHE_ENTRY_INFOA internetCacheEntry;
     152:             IntPtr enumHandle = IntPtr.Zero;
     153:             bool returnValue = false;
     154:  
     155:             // Delete the groups first.
     156:             // Groups may not always exist on the system.
     157:             // For more information, visit the following Microsoft Web site:
     158:             // http://msdn.microsoft.com/library/?url=/workshop/networking/wininet/overview/cache.asp            
     159:             // By default, a URL does not belong to any group. Therefore, that cache may become
     160:             // empty even when the CacheGroup APIs are not used because the existing URL does not belong to any group.            
     161:             enumHandle = FindFirstUrlCacheGroup(0, CACHEGROUP_SEARCH_ALL, IntPtr.Zero, 0, ref groupId, IntPtr.Zero);
     162:             // If there are no items in the Cache, you are finished.
     163:             if (enumHandle != IntPtr.Zero && ERROR_NO_MORE_ITEMS == Marshal.GetLastWin32Error())
     164:                 return;
     165:  
     166:             // Loop through Cache Group, and then delete entries.
     167:             while (true)
     168:             {
     169:                 if (ERROR_NO_MORE_ITEMS == Marshal.GetLastWin32Error() || ERROR_FILE_NOT_FOUND == Marshal.GetLastWin32Error()) { break; }
     170:                 // Delete a particular Cache Group.
     171:                 returnValue = DeleteUrlCacheGroup(groupId, CACHEGROUP_FLAG_FLUSHURL_ONDELETE, IntPtr.Zero);
     172:                 if (!returnValue && ERROR_FILE_NOT_FOUND == Marshal.GetLastWin32Error())
     173:                 {
     174:                     returnValue = FindNextUrlCacheGroup(enumHandle, ref groupId, IntPtr.Zero);
     175:                 }
     176:  
     177:                 if (!returnValue && (ERROR_NO_MORE_ITEMS == Marshal.GetLastWin32Error() || ERROR_FILE_NOT_FOUND == Marshal.GetLastWin32Error()))
     178:                     break;
     179:             }
     180:  
     181:             // Start to delete URLs that do not belong to any group.
     182:             enumHandle = FindFirstUrlCacheEntry(null, IntPtr.Zero, ref cacheEntryInfoBufferSizeInitial);
     183:             if (enumHandle != IntPtr.Zero && ERROR_NO_MORE_ITEMS == Marshal.GetLastWin32Error())
     184:                 return;
     185:  
     186:             cacheEntryInfoBufferSize = cacheEntryInfoBufferSizeInitial;
     187:             cacheEntryInfoBuffer = Marshal.AllocHGlobal(cacheEntryInfoBufferSize);
     188:             enumHandle = FindFirstUrlCacheEntry(null, cacheEntryInfoBuffer, ref cacheEntryInfoBufferSizeInitial);
     189:  
     190:             while (true)
     191:             {
     192:                 internetCacheEntry = (INTERNET_CACHE_ENTRY_INFOA)Marshal.PtrToStructure(cacheEntryInfoBuffer, typeof(INTERNET_CACHE_ENTRY_INFOA));
     193:                 if (ERROR_NO_MORE_ITEMS == Marshal.GetLastWin32Error()) { break; }
     194:  
     195:                 cacheEntryInfoBufferSizeInitial = cacheEntryInfoBufferSize;
     196:                 returnValue = DeleteUrlCacheEntry(internetCacheEntry.lpszSourceUrlName);
     197:                 if (!returnValue)
     198:                 {
     199:                     returnValue = FindNextUrlCacheEntry(enumHandle, cacheEntryInfoBuffer, ref cacheEntryInfoBufferSizeInitial);
     200:                 }
     201:                 if (!returnValue && ERROR_NO_MORE_ITEMS == Marshal.GetLastWin32Error())
     202:                 {
     203:                     break;
     204:                 }
     205:                 if (!returnValue && cacheEntryInfoBufferSizeInitial > cacheEntryInfoBufferSize)
     206:                 {
     207:                     cacheEntryInfoBufferSize = cacheEntryInfoBufferSizeInitial;
     208:                     cacheEntryInfoBuffer = Marshal.ReAllocHGlobal(cacheEntryInfoBuffer, (IntPtr)cacheEntryInfoBufferSize);
     209:                     returnValue = FindNextUrlCacheEntry(enumHandle, cacheEntryInfoBuffer, ref cacheEntryInfoBufferSizeInitial);
     210:                 }
     211:             }
     212:             Marshal.FreeHGlobal(cacheEntryInfoBuffer);
     213:         }
     214:         #endregion
     215:     }
     216: }
