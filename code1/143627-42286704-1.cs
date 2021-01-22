        int Mx;
		int My;
		int Sw;
		int Sh;
		
		bool mov;
        void SizerMouseDown(object sender, MouseEventArgs e)
		{
			mov = true;
			My = MousePosition.Y;
			Mx = MousePosition.X;
			Sw = Width;
			Sh = Height;
		}
		
		void SizerMouseMove(object sender, MouseEventArgs e)
		{
			if (mov == true) {
				Width = MousePosition.X - Mx + Sw;
				Height = MousePosition.Y - My + Sh;
			}
		}
		
		void SizerMouseUp(object sender, MouseEventArgs e)
		{
			mov = false;
		}
