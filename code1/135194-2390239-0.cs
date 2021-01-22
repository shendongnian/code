    struct Item
    {
        // The requirements say everything is an item.
    };
    
    struct Document
    : public Item
    {
        // There are documents
    };
    
    struct Document_Physical
    : public Document
    {
        // Physical documents
    };
    
    struct Document_Electronic
    : public Document
    {
        // Electronic documents
    };
    
    struct Computer
    : public Item
    {
    };
