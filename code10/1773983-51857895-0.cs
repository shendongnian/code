    switch (control.Type)
       {
         case WdContentControlType.wdContentControlText:
           var text = control.Range.Text;
           //var pt = control as PlainTextContentControl;// pt is null
           Console.WriteLine(text); 
          break;
         case WdContentControlType.wdContentControlRichText:
            var richText = control.Range.Text;
            //var pt1 = control as PlainTextContentControl;// pt1 is null
            Console.WriteLine(richText); 
            break;
          }
