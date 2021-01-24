    using namespace System;
    using namespace System::Globalization;
    
    int main()
    {
    	array<String^> ^months = DateTimeFormatInfo::CurrentInfo->MonthNames;
    }
