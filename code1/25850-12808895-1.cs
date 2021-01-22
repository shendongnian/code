    //pseudo-assembly
    Produce consumable[0]                   // expensive operation, e.g. disk I/O
    Produce consumable[1]                   // waiting...
    Produce consumable[2]                   // waiting...
    Produce consumable[3]                   // completed the consumable list
    Consume consumable[0]                   // start consuming
    Consume consumable[1]
    Consume consumable[2]
    Consume consumable[3]
