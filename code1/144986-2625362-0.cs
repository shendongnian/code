    TextPointer ptr1= RichTextBox.CaretPosition.DocumentStart.GetPositionAtOffset(Index);
    
    char nextChar = GetNextChar();
    //we continue until there is a character
    while (char.IsWhiteSpace(nextChar))
    {
       Index++;
       ptr1= RichTextBox.CaretPosition.DocumentStart.GetPositionAtOffset(Index);
       nextChar = GetCharacterAt(Ptr1);
    }
    //so now ptr1 is pointing to a character, and we do something with that TextPointer
    ChangeFormat(ptr1);
