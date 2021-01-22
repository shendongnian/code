    		HWND hWndToHide = FindWindow(_T("HHTaskBar"), NULL);
			if(hWndToHide) {
				if(iEnabled) {
						// Disable VanillaCE TaskBar
					if(IsWindowVisible(hWndToHide))
						ShowWindow(hWndToHide, SW_HIDE);			
						// Disable SIPWnd (On Screen Keyboard).
					hWndToHide = FindWindow(_T("SipWndClass"), NULL);
					if(hWndToHide && IsWindowVisible(hWndToHide))
						ShowWindow(hWndToHide, SW_HIDE);			
				}
				else {
						// Enable VanillaCE TaskBar
					if(!IsWindowVisible(hWndToHide))
						ShowWindow(hWndToHide, SW_SHOW); 
				}				
			}	
