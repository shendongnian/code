    foreach( var oneThing in YourListOfToBeAddedItems )
    {
       var mc = new MyControl();
       mc.MyText1 = oneThing.TextFieldUsedForField1;
       mc.MyText2 = oneThing.FieldForSecondText;
       mc.MyText3 = oneThing.ThirdTextBasisForDisplay;
       // Now, add the "mc" to whatever your control is
       // can't confirm this line below as I dont know context
       // of your form and dynamic adding.
       YourWindowGridOrOtherControl.Controls.Add( mc );
    }
