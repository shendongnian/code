     public enum MyLotusFieldType
     {
        //http://publib.boulder.ibm.com/infocenter/domhelp/v8r0/index.jsp?topic=/com.ibm.designer.domino.main.doc/H_TYPE_PROPERTY_ITEM.html
        // Legal values
        ACTIONCD = 16,// means saved action CD records; non-Computable; canonical form. 
        ASSISTANTINFO = 17,// means saved assistant information; non-Computable; canonical form. 
        ATTACHMENT = 1084,// means file attachment. 
        AUTHORS = 1076,// means authors. 
        COLLATION = 2,//. 
        // Note This value is new with Release 6
        DATETIMES = 1024, //means date-time value or range of date-time values. 
        EMBEDDEDOBJECT = 1090, //means embedded object. 
        ERRORITEM = 256, //means an error occurred while accessing the type. 
        FORMULA = 1536, //means Notes formula. 
        HTML = 21, //means HTML source text. 
        ICON = 6, //means icon. 
        LSOBJECT = 20, //means saved LotusScript Object code for an agent. 
        MIME_PART = 25, //means MIME support. 
        NAMES = 1074, //means names. 
        NOTELINKS = 7, //means link to a database, view, or document. 
        NOTEREFS = 4, //means reference to the parent document. 
        NUMBERS = 768, //means number or number list. 
        OTHEROBJECT = 1085, //means other object. 
        QUERYCD = 15, //means saved query CD records; non-Computable; canonical form. 
        READERS = 1075, //means readers. 
        RFC822Text = 1282, //means RFC822 Internet mail text. 
        RICHTEXT = 1, //means rich text. 
        SIGNATURE = 8, //means signature. 
        TEXT = 1280, //means text or text list. 
        UNAVAILABLE = 512, //means the item type isn't available. 
        UNKNOWN = 0, //means the item type isn't known. 
        USERDATA = 14, //means user data. 
        USERID = 1792, //means user ID name. 
        VIEWMAPDATA = 18, //means saved ViewMap dataset; non-Computable; canonical form. 
        VIEWMAPLAYOUT = 19 //means saved ViewMap layout; non-Computable; canonical form
    }
