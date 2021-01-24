    private void UpdateInterface(PassportDatabaseReader.Passport _passport)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<PassportDatabaseReader.Passport>(UpdateInterface), new object[] { _passport });
                return;
            }
            else
            {
                ControlHelper.SuspendDrawing(this);
                new Thread(() => ChangeBackground(BackgroundPassport)).Start();
                lPassportNumberNo.Text = _passport.PassportNo;
                strPassportNo = _passport.PassportNo;
                lPassengerName.Text = _passport.Name.Replace('$','\n');
                lPax.Text = _passport.Pax;
                lTableNo.Text = _passport.TableNo;
                lRoomNo.Text = _passport.RoomNo;
                pbTables.Hide();
                try
                {
                    pbPasspic.Load("..\\..\\Pics\\" + _passport.PassportNo + ".png");
                    pbPasspic.Show();
                    pbTables.ImageLocation = "..\\..\\Tischordnung_" + _passport.TableNo + ".png";
                    pbTables.Show();
                }
                catch (Exception)
                {
                    throw;
                }
                ControlHelper.ResumeDrawing(this);
            }
        }
