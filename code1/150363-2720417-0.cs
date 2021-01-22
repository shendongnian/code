    String ^text = "Some   text  to process";
    bool spaces = false;
    // make the following static and just clear it rather than reallocating it every time
    System::Text::StringBuilder ^output = gcnew System::Text::StringBuilder;
    for (int i = 0, l = text->Length ; i < l ; ++i)
    {
      if (spaces)
      {
        if (text [i] != ' ')
        {
          output->Append (text [i]);
          spaces = false;
        }
      }
      else
      {
        output->Append (text [i]);
        if (text [i] == ' ')
        {
          spaces = true;
        }
      }
    }
    text = output->ToString ();
