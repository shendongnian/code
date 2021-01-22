           private bool IsOKForDecimalTextBox(char theCharacter, TextBox theTextBox)
        {
            // Only allow control characters, digits, plus and minus signs.
            // Only allow ONE plus sign.
            // Only allow ONE minus sign.
            // Only allow the plus or minus sign as the FIRST character.
            // Only allow ONE decimal point.
            // Do NOT allow decimal point or digits BEFORE any plus or minus sign.
            if (
                !char.IsControl(theCharacter)
                && !char.IsDigit(theCharacter)
                && (theCharacter != '.')
                && (theCharacter != '-')
                && (theCharacter != '+')
            )
            {
                // Then it is NOT a character we want allowed in the text box.
                return false;
            }
            // Only allow one decimal point.
            if (theCharacter == '.'
                && theTextBox.Text.IndexOf('.') > -1)
            {
                // Then there is already a decimal point in the text box.
                return false;
            }
            // Only allow one minus sign.
            if (theCharacter == '-'
                && theTextBox.Text.IndexOf('-') > -1)
            {
                // Then there is already a minus sign in the text box.
                return false;
            }
            // Only allow one plus sign.
            if (theCharacter == '+'
                && theTextBox.Text.IndexOf('+') > -1)
            {
                // Then there is already a plus sign in the text box.
                return false;
            }
            // Only allow one plus sign OR minus sign, but not both.
            if (
                (
                    (theCharacter == '-')
                    || (theCharacter == '+')
                )
                && 
                (
                    (theTextBox.Text.IndexOf('-') > -1)
                    ||
                    (theTextBox.Text.IndexOf('+') > -1)
                )
                )
            {
                // Then the user is trying to enter a plus or minus sign and
                // there is ALREADY a plus or minus sign in the text box.
                return false;
            }
            // Only allow a minus or plus sign at the first character position.
            if (
                (
                    (theCharacter == '-')
                    || (theCharacter == '+')
                )
                && theTextBox.SelectionStart != 0
                )
            {
                // Then the user is trying to enter a minus or plus sign at some position 
                // OTHER than the first character position in the text box.
                return false;
            }
            // Only allow digits and decimal point AFTER any existing plus or minus sign
            if  (
                    (
                        // Is digit or decimal point
                        char.IsDigit(theCharacter)
                        ||
                        (theCharacter == '.')
                    )
                    &&
                    (
                        // A plus or minus sign EXISTS
                        (theTextBox.Text.IndexOf('-') > -1)
                        ||
                        (theTextBox.Text.IndexOf('+') > -1)
                    )
                    &&
                        // Attempting to put the character at the beginning of the field.
                        theTextBox.SelectionStart == 0
                )
            {
                // Then the user is trying to enter a digit or decimal point in front of a minus or plus sign.
                return false;
            }
            // Otherwise the character is perfectly fine for a decimal value and the character
            // may indeed be placed at the current insertion position.
            return true;
        }
