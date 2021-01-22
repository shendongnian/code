    private void SetPictureBoxEvents()
        {
            Andromeda.MouseEnter += new EventHandler(new HeroMouseHandler("Andromeda.jpg").HeroMouseEnter);
            Engineer.MouseEnter += new EventHandler(new HeroMouseHandler("Engineer.jpg").HeroMouseEnter);
            Nighthound.MouseEnter += new EventHandler(new HeroMouseHandler("Nighthound.jpg").HeroMouseEnter);
            Swiftblade.MouseEnter += new EventHandler(new HeroMouseHandler("Swiftblade.jpg").HeroMouseEnter);
        }
