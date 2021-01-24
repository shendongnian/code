    private void button_Attack_Click(object sender, EventArgs e)
        {
            button_Play.Enabled = false;
            Character P1 = (Character)comboBox_CharacterSelectionP1.SelectedItem;
            Character P2 = (Character)comboBox_CharacterSelectionP2.SelectedItem;
            if (P1.Counter % 2 == 0)
            {
                double DMG_1 = P1.Attack();
                label_Player1_HP.Text = P1.HealthPoints.ToString("F3");
                label_AttackValueP1.Text = $"Damage inflicted: {DMG_1.ToString("F3")}";
                label_Message.Text = $"{P1.Name} throws a punch";
                P2.HealthPoints -= DMG_1;
                label_Player2_HP.Text = P2.HealthPoints.ToString("F3");
                P1.Counter++;
            }
            else...
