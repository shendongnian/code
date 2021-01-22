	                 static ulong Rol_ByVal(this ulong ul) => (ul << 1) | (ul >> 63);
	// 00007FF969CD0760  push        rbp  
	// 00007FF969CD0761  sub         rsp,20h  
	// 00007FF969CD0765  lea         rbp,[rsp+20h]  
    // ...
	// 00007FF969CE0E4C  mov         rax,qword ptr [rbp+10h]  
	// 00007FF969CE0E50  rol         rax,1  
	// 00007FF969CD0798  lea         rsp,[rbp]  
	// 00007FF969CD079C  pop         rbp  
	// 00007FF969CD079D  ret  
	                 static void Rol_ByRef(ref this ulong ul) => ul = (ul << 1) | (ul >> 63);
	// 00007FF969CD0760  push        rbp  
	// 00007FF969CD0761  sub         rsp,20h  
	// 00007FF969CD0765  lea         rbp,[rsp+20h]  
    // ...
	// 00007FF969CE0E8C  mov         rax,qword ptr [rbp+10h]  
	// 00007FF969CE0E90  rol         qword ptr [rax],1              <--- !
	// 00007FF969CD0798  lea         rsp,[rbp]  
	// 00007FF969CD079C  pop         rbp  
	// 00007FF969CD079D  ret  
