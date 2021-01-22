      Button[] numberButtons=new Button[] { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btnDecimalPt};
      Button[] operationButtons=new Button[] { btnDiv, btnMult, btnSubtract, btnAdd };
      foreach (var b in numberButtons)
           b.Click += new System.EventHandler(this.Number_Click);
      foreach (var b in operationButtons)
          b.Click += new System.EventHandler(this.Operation_Click);
      // etc
      Button[][] allButtons=
      {
          new Button[] {btnSqrt, btnExp, btn10x, btnPow,btnMultInverse, btnCHS, null, null, null, null}, 
          new Button[] {btnN, btnInterest, btnPMT, btnPV, btnFV, null, btn7, btn8, btn9, btnDiv}, 
          new Button[] {btnLn, btnLog, btnSine, btnCosine, btnTangent, btnPi, btn4, btn5, btn6, btnMult}, 
          new Button[] {btnRoll, btnSwap, btnCLRfin, btnCLX, btnCLR, btnEnter, btn1, btn2, btn3, btnSubtract}, 
          new Button[] {btnInt, btnFrac, btnFix, btnStore, btnRecall, null, btn0, btnDecimalPt, btnNotUsed, btnAdd}
      };
      // programmatically set the location
      int col,row;
      for(row=0; row < allButtons.Length; row++)
      {
          Button[] ButtonCol= allButtons[row];
          for (col=0; col < ButtonCol.Length; col++)
          {
              if (ButtonCol[col]!=null)
              {
                  ButtonCol[col].TabIndex = col + (row * allButtons.Length) +1;
                  ButtonCol[col].Font = font1; 
                  ButtonCol[col].BackColor = System.Drawing.SystemColors.ControlDark;
                  ButtonCol[col].Size=new System.Drawing.Size(stdButtonWidth, stdButtonHeight);
                  ButtonCol[col].Location=new Point(startX + (col * stdButtonWidth), 
                                                    startY + (row * stdButtonHeight) ) ;
              }
          }
      }
