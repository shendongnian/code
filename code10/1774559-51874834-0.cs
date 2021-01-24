    var stoppedPallets = this.Pallets.Where(p => !p.IsMoving).ToList();
    var movingPallets = this.Pallets.Where(p => p.IsMoving).ToList();
    foreach (var movingPallet in movingPallets)
    {
       var movingBounds = movingPallet.BoundsRelativeTo(this.AnimationGrid);
       if (stoppedPallets.Any(
          p => p.BoundsRelativeTo(this.AnimationGrid).IntersectsWith(movingBounds)))
       {
          movingPallet.Storyboard.Pause(this);
          movingPallet.IsMoving = false;
       }
    }
