		/// <summary>
		/// Get the component path.
		/// </summary>
		/// <param name="product">The product GUI as string with {}.</param>
		/// <param name="component">The component GUI as string with {}.</param>
		/// <param name="pathBuf">The path buffer.</param>
		/// <param name="buff">The buffer to receive the path (use a <see cref="StringBuilder"/>).</param>
		/// <returns>A obscure Win32 API error code.</returns>
		[DllImport("MSI.DLL", CharSet = CharSet.Unicode)]
		internal static extern uint MsiGetComponentPath(
			string product,
			string component,
			StringBuilder pathBuf,
			ref int buff);
