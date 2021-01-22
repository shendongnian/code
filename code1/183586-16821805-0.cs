    /// <summary>
            /// Removes all related DNS records for the given hostname from the DNS resolver cache.
            /// </summary>
            /// <param name="hostName">The host name to flush from the resolver cache.</param>
            /// <returns>Returns 1 if successful, zero if failed.  No other error information is returned.</returns>
            /// <remarks>
            /// DnsFlushResolverCacheEntry_W is an undocumented method.  From dissembler this method has two possible 
            /// return values 0 or 1.  If the argument is null or the _R_ResolverFlushCacheEntry returns something 
            /// other than zero than the return value is zero.  When _R_ResolverFlushCacheEntry returns zero the 
            /// return value is 1.  Based off this and testing of the method it is assumed that 1 is used to indicate success.  
            /// After calling this method querying the DNS resolver cache returns no results.
            /// 
            /// __stdcall DnsFlushResolverCacheEntry_W(x)
            /// ....
            /// 6DC12729 xor     esi, esi					    // Zero esi
            /// 6DC1272B cmp     [ebp+arg_0], esi  			    // check if the hostname is null
            /// 6DC1272E jz      loc_6DC1D8B8 				    // Jump to end, return value is 0.
            /// 6DC12734 mov     [ebp+ms_exc.registration.TryLevel], esi
            /// 6DC12737 push    esi					        // Push 3 args for method, 2nd is hostname, others null
            /// 6DC12738 push    [ebp+arg_0]
            /// 6DC1273B push    esi
            /// 6DC1273C call    _R_ResolverFlushCacheEntry@12	// call this method 
            /// 6DC12741 mov     [ebp+var_1C], eax 			    // store return value in local
            /// 6DC12744 mov     [ebp+ms_exc.registration.TryLevel], 0FFFFFFFEh
            /// 6DC1274B
            /// 6DC1274B loc_6DC1274B:                           
            /// 6DC1274B cmp     [ebp+var_1C], esi 			 
            /// 6DC1274E jnz     loc_6DC1D8E7				    // Error?  jump to block that does etw then return 0
            /// 6DC12754 xor     eax, eax					    // Success?  Set eax to zero
            /// 6DC12756 inc     eax					        // result is 0, increment by 1.  success return value is 1
            /// 6DC12757 call    __SEH_epilog4
            /// 6DC1275C retn    4
            /// 
            /// 6DC1D8B8 xor     eax, eax					    // set return value to zero
            /// 6DC1D8BA jmp     loc_6DC12757				    // jump to end
            /// 
            /// 6DC1D8E7 mov     eax, _WPP_GLOBAL_Control
            /// 6DC1D8EC cmp     eax, offset _WPP_GLOBAL_Control
            /// 6DC1D8F1 jz      short loc_6DC1D8B8
            /// 6DC1D8F3 test    byte ptr [eax+1Ch], 40h
            /// 6DC1D8F7 jz      short loc_6DC1D8B8	// This is probably testing some flag that is used to indicate if ETW is enabled
            /// 6DC1D8F9 push    [ebp+var_1C]
            /// 6DC1D8FC push    offset dword_6DC22494
            /// 6DC1D901 push    0Dh
            /// 6DC1D903 push    dword ptr [eax+14h]
            /// 6DC1D906 push    dword ptr [eax+10h]
            /// 6DC1D909 call    _WPP_SF_q@20    ; WPP_SF_q(x,x,x,x,x)  	// This method does some ETW tracing
            /// 6DC1D90E jmp     short loc_6DC1D8B8
            /// </remarks>
            [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCacheEntry_W", CharSet = CharSet.Unicode)]
            public static extern int DnsFlushResolverCacheEntry(string hostName);
