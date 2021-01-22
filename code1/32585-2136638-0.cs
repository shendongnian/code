	typedef struct
	{
		USHORT ParameterOneOffset;	// The offset of the first parameter in dwords starting at one
		USHORT ParameterTwoOffset;	// The offset of the second parmaeter in dwords starting at one
	} FastCallParameterInfo;
    	__declspec( naked,dllexport ) void __stdcall InvokeFast()
	{
		FastCallParameterInfo paramInfo;
		int functionAddress;
		int retAddress;
		int paramOne, paramTwo;
		__asm
		{
			// Pop the return address and parameter info.  Store in memory.
			pop retAddress;
			pop paramInfo;
			pop functionAddress;
			// Check if any parameters should be stored in edx							
			movzx ecx, paramInfo.ParameterOneOffset;	 
			cmp ecx,0;
			je NoRegister;	
			// Calculate the offset for parameter one.
			movzx ecx, paramInfo.ParameterOneOffset;	// Move the parameter one offset to ecx
			dec ecx;									// Decrement by 1
			mov eax, 4;									// Put 4 in eax
			mul ecx;									// Multiple offset by 4
			// Copy the value from the stack on to the register.
			mov ecx, esp;								// Move the stack pointer to ecx
			add ecx, eax;								// Subtract the offset.
			mov eax, ecx;								// Store in eax for later.
			mov ecx, [ecx];								// Derefernce the value
			mov paramOne, ecx;							// Store the value in memory.
			// Fix up stack
			add esp,4;									// Decrement the stack pointer
			movzx edx, paramInfo.ParameterOneOffset;	// Move the parameter one offset to edx
			dec edx;									// Decrement by 1
			cmp edx,0;									// Compare offset with zero
			je ParamOneNoShift;							// If first parameter then no shift.
		ParamOneShiftLoop:
			mov ecx, eax;
			sub ecx, 4;
			mov ecx, [ecx]
			mov [eax], ecx;								// Copy value over
			sub eax, 4;									// Go to next 
			dec edx;									// decrement edx
			jnz ParamOneShiftLoop;						// Loop
		ParamOneNoShift:
			// Check if any parameters should be stored in edx							
			movzx ecx, paramInfo.ParameterTwoOffset;	 
			cmp ecx,0;
			je NoRegister;	
			movzx ecx, paramInfo.ParameterTwoOffset;	// Move the parameter two offset to ecx
			sub ecx, 2;									// Increment the offset by two.  One extra for since we already shifted for ecx
			mov eax, 4;									// Put 4 in eax
			mul ecx;									// Multiple by 4
			// Copy the value from the stack on to the register.
			mov ecx, esp;								// Move the stack pointer to ecx
			add ecx, eax;								// Subtract the offset.
			mov eax, ecx;								// Store in eax for later.
			mov ecx, [ecx];								// Derefernce the value
			mov paramTwo, ecx;							// Store the value in memory.			
			// Fix up stack
			add esp,4;									// Decrement the stack pointer
			movzx edx, paramInfo.ParameterTwoOffset;	// Move the parameter two offset to ecx
			dec edx;									// Decrement by 1
			cmp edx,0;									// Compare offset with zero
			je NoRegister;								// If first parameter then no shift.
		ParamTwoShiftLoop:
			mov ecx, eax;
			sub ecx, 4;
			mov ecx, [ecx]
			mov [eax], ecx;								// Copy value over
			sub eax, 4;									// Go to next 
			dec edx;									// decrement edx
			jnz ParamTwoShiftLoop;						// Loop
			
		NoRegister:
			mov ecx, paramOne;							// Copy value from memory to ecx register
			mov edx, paramTwo;							// 
			push retAddress;
			jmp functionAddress;
		}
	}
}
