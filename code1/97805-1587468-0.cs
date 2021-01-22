    private void ChangeTextProperty(DependencyProperty dp, string value)
                {
                    if (mainRTB == null) return;
                    TextSelection ts = mainRTB.Selection;
                    if (ts.IsEmpty)
                    {
                        TextPointer caretPos = mainRTB.CaretPosition;
                        TextRange tr = new TextRange(caretPos, caretPos);
                        tr.Text = " ";
                        tr.ApplyPropertyValue(dp, value);
                    }
                    else
                    {
                        ts.ApplyPropertyValue(dp, value);
                    }
                }
