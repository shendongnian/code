                                AnimationExtender rowFader = new AnimationExtender();
                            rowFader.TargetControlID = tr.ID;
                            rowFader.ID = "aeRowFader-" + rowToFade_;
                            string animationXML =
                                @"<OnLoad>
                                    <Sequence>
                                        <Color PropertyKey=""color"" StartValue=""FFFF00"" EndValue=""#FFFFFF"" />
                                        <FadeIn />
                                    </Sequence>
                                </OnLoad>";
                            rowFader.Animations = animationXML;
                                
                            
                            rowToFade_ = 0;
                            column1.Controls.Add(rowFader);
