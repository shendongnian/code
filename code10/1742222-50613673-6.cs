    [
        uuid(962232C8-90B2-4B61-8EF3-83298901C63E),
        version(1.0),
        custom(0F21F359-AB84-41E8-9A78-36D110E6D2F9, "CSCOMLIB.ICSCOMCLASS")    
    ]
    dispinterface ICSCOMCLASS {
        properties:
        methods:
            [id(0x00000001)]
            void TestInParameter([in] double num);
            [id(0x00000002)]
            void TestOutParameter([out] double* num);
            [id(0x00000003)]
            void TestRefParameter([in, out] double* num);
    };
