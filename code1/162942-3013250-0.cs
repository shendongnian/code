    //       3 3 2 2 2 2 2 2 2 2 2 2 1 1 1 1 1 1 1 1 1 1
    //       1 0 9 8 7 6 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0 9 8 7 6 5 4 3 2 1 0
    //      +---------------+---------------+-------------------------------+
    //      |G|G|G|G|Res'd|A| StandardRights|         SpecificRights        |
    //      |R|W|E|A|     |S|               |                               |
    //      +-+-------------+---------------+-------------------------------+
    //
    //      typedef struct _ACCESS_MASK {
    //          WORD   SpecificRights;
    //          BYTE  StandardRights;
    //          BYTE  AccessSystemAcl : 1;
    //          BYTE  Reserved : 3;
    //          BYTE  GenericAll : 1;
    //          BYTE  GenericExecute : 1;
    //          BYTE  GenericWrite : 1;
    //          BYTE  GenericRead : 1;
    //      } ACCESS_MASK;
    //      typedef ACCESS_MASK *PACCESS_MASK;
    //
    //  but to make life simple for programmer's we'll allow them to specify
    //  a desired access mask by simply OR'ing together mulitple single rights
    //  and treat an access mask as a DWORD.  For example
    //
    //      DesiredAccess = DELETE | READ_CONTROL
