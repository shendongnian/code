    1. Click Start, click Run, type regedit, and then click OK.
    2. Locate and then click the following registry subkey:
     - HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control
    3. In the right pane, locate the ServicesPipeTimeout entry.
    
    **Note**: If the ServicesPipeTimeout entry does not exist, you must create it. To do this, follow these steps:
    
     - On the Edit menu, point to New, and then click DWORD Value.
     - Type ServicesPipeTimeout, and then press ENTER. 
    4. Right-click ServicesPipeTimeout, and then click Modify.
    5. Click Decimal, type 60000, and then click OK.
     - This value represents the time in milliseconds before a service times out.
    6. Restart the computer.
