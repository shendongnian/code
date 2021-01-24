    private void makeNewItem(MovingObject item)
    {
      if (item is Car)
      {
        autos.Add((Car)item);
      }
      else if (item is Truck)
      {
        bestelwagens.Add((Truck)item);
      }
      else
      {
        personeelsleden.Add((Person)item);
      }
      listBoxBedrijf.Items.Add(item);
      //Assuming NieuweLocatieEvent is public
      item.NieuweLocatieEvent += updateLocatie;
    }
