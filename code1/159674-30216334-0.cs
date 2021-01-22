        /// <summary>Specify the data type to retrieve from the registry</summary>
        /// <remarks> https://msdn.microsoft.com/en-us/library/windows/desktop/ms724884%28v=vs.85%29.aspx </remarks>
        public enum RegDataType
        {
            /// <summary>[0] No defined value type.</summary>
            REG_NONE,
            /// <summary>[1] Null-terminated string. 
            /// It will be a Unicode or ANSI string, depending on whether you use the Unicode or ANSI functions.</summary>
            REG_SZ,
            /// <summary>[2] Null-terminated string that contains unexpanded references to environment variables (for example, "%PATH%"). 
            /// It will be a Unicode or ANSI string, depending on whether you use the Unicode or ANSI functions.</summary>
            REG_EXPAND_SZ,
            /// <summary>[3] Binary data in any form.</summary>
            REG_BINARY,
            /// <summary>[4] 32-bit number.</summary>
            REG_DWORD,
           /* /// <summary> [4] 32-bit number in little-Endean format. This is equivalent to REG_DWORD.
              /// In little-Endean format, a multi-byte value is stored in memory from the lowest byte (the "little end") to the highest byte. 
              //// For example, the value 0x12345678 is stored as (0x78 0x56 0x34 0x12) in little-Endean format.</summary>
           */ //REG_DWORD_LITTLE_ENDIAN 4
            /// <summary>[5] 32-bit number in big-Endean format.
            /// In big-Endean format, a multi-byte value is stored in memory from the highest byte (the "big end") to the lowest byte.
            /// For example, the value 0x12345678 is stored as (0x12 0x34 0x56 0x78) in big-Endean format.</summary>
            REG_DWORD_BIG_ENDIAN,
            /// <summary>[6]Unicode symbolic link.</summary>
            REG_LINK,
            /// <summary>[7] Array of null-terminated strings that are terminated by two null characters.</summary>
            REG_MULTI_SZ,
            /// <summary>[8]Device-driver resource list.</summary>
            REG_RESOURCE_LIST,
            
            /// <summary>[9] </summary>
            REG_FULL_RESOURCE_DESCRIPTOR,
            
            /// <summary>[10] </summary>
            REG_RESOURCE_REQUIREMENTS_LIST,
            /// <summary>[11] 64-bit number.</summary>
            REG_QWORD
          /*  /// <summary>[11] A 64-bit number in little-Endean format. This is equivalent to REG_QWORD.</summary>
          */  //REG_QWORD_LITTLE_ENDIAN 11 
        }
