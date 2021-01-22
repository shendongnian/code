    private void Fill(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            object[] list =
                {
                    new ComboBoxItem<int>("Architekt", 1),
                    new ComboBoxItem<int>("Bauträger", 2),
                    new ComboBoxItem<int>("Fachbetrieb/Installateur", 3),
                    new ComboBoxItem<int>("GC-Haus", 5),
                    new ComboBoxItem<int>("Ingenieur-/Planungsbüro", 9),
                    new ComboBoxItem<int>("Wowi", 17),
                    new ComboBoxItem<int>("Endverbraucher", 19)
                };
            comboBox.Items.AddRange(list);
        }
